Shader "Unlit/Glass1"
{
    Properties
    {
        _ColorTop ("Top Color", Color) = (1, 1, 1, 1)
        _ColorBottom ("Bottom Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Pass
        {
            ZWrite Off
            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            float4 _ColorTop;
            float4 _ColorBottom;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            Interpolators vert(MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv;
                return o;
            }

            float InverseLerp(float a, float b, float v)
            {
                return (v - a) / (b - a);
            }

            fixed4 frag(Interpolators i) : SV_Target
            {
                float4 gradient = lerp(_ColorTop, _ColorBottom, i.uv.y);
                float lineFactor = (sin(i.uv.y * 50) + 4) / 5;

                return gradient * (lineFactor * (sin(_Time.y * 2) + 3) / 5);
            }
            ENDCG
        }
    }
}
