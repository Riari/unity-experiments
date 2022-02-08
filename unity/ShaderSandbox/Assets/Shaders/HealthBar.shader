Shader "Unlit/HealthBar"
{
    Properties
    {
        _Value ("Value", Range(0.0, 1.0)) = 0.5
        _ColorBar ("Bar color", Color) = (1, 1, 1, 1)
        _ColorFillMin ("Min fill color", Color) = (1, 1, 1, 1)
        _ColorFillMax ("Max fill color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Value;
            float4 _ColorBar;
            float4 _ColorFillMin;
            float4 _ColorFillMax;

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
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(Interpolators i) : SV_Target
            {
                return i.uv.x <= _Value ? lerp(_ColorFillMin, _ColorFillMax, _Value) : _ColorBar;
            }
            ENDCG
        }
    }
}
