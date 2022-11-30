Shader "Unlit/HealthBar"
{
    Properties
    {
        _Value ("Value", Range(0.0, 1.0)) = 0.5
        _BarColor ("Bar color", Color) = (0, 0, 0, 1)
        _MaskTexture ("Mask texture", 2D) = "" {}
        _ContainerTexture ("Container texture", 2D) = "" {}
        _FillTexture ("Fill texture", 2D) = "green" {}
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Overlay"
        }

        ZTest Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Value;
            float4 _BarColor;
            sampler2D _MaskTexture;
            sampler2D _ContainerTexture;
            sampler2D _FillTexture;
            float4 _FillTexture_ST;

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            Interpolators vert(MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _FillTexture);
                return o;
            }

            fixed4 frag(Interpolators i) : SV_Target
            {
                float4 fill = tex2D(_FillTexture, float2(_Value, i.uv.y));
                if (_Value < 0.25) fill *= (sin(_Time.y * 12) + 6) / 5;
                float4 color = i.uv.x <= _Value ? fill : _BarColor;

                color *= tex2D(_MaskTexture, i.uv).a;
                float4 container = tex2D(_ContainerTexture, i.uv);
                color = lerp(color, container, container.a);
                
                return color;
            }
            ENDCG
        }
    }
}
