Shader"Unlit/WeLiveInSpainWithoutTheA_SpinAndMove"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0.1, 10)) = 1.0
        _Amplitude ("Amplitude", Range(0.1, 2)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                            UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Speed;
            float _Amplitude;

            v2f vert(appdata v)
            {
                v2f o;
                float time = _Time.y * _Speed;
                float yPos = sin(time) * _Amplitude;

                float3 pos = float3(v.vertex.x, v.vertex.y + yPos, v.vertex.z);

                float3x3 rotationMatrix = float3x3(cos(time), 0, sin(time), 0, 1, 0, -sin(time), 0, cos(time));
                pos = mul(rotationMatrix, pos);

                o.vertex = UnityObjectToClipPos(float4(pos, 1.0));
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                            // Sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                            // Apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
