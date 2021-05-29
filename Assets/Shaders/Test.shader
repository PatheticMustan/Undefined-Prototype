Shader "Custom/Test"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _MyColor ("Check", Color) = (1,1,1,1)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MyColor;
            float4 _ColorList[16];

            uint _ColorListLength = 4;
            uint _Cycle = 0;
            uint _CycleCounter = 1;

            float _Timer;


            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;

                //sin(i.vertex.y/100 + _Time[1] )/3)

                /*
                if ((int)(i.vertex.y * _ScreenParams.y) % 256 >= 5128)
                {
                    //col = tex2D(_MainTex, i.uv + float2(cos(i.vertex.y/100 + _Time[3])/10 , 0));
                    col = tex2D(_MainTex, i.uv + float2(sin(i.vertex.y/50 + _Time[3]) / 10, 0));
				}
                else
                {
                
                    col = tex2D(_MainTex, i.uv + float2( (acos(cos(i.vertex.x/25 + _Time[3])) - 1.57 ) / 40 + (acos(cos(i.vertex.y/10 + _Time[3])) - 1.57 ) / 40, (acos(cos(i.vertex.x/30 + _Time[3])) - 1.57 ) / 40));
                }
                */
                
                
                
                //sin(i.vertex.y/10 + _Time[3] )/10)
                
                
                if ((i.vertex.y * _ScreenParams.y) % 2 >= 15)
                col = tex2D(_MainTex, i.uv + float2(sin((i.vertex.y)/10 + _Time[3])/50, sin((1 - i.vertex.y)/10 + _Time[3] )/10));
                else
                {
                col = tex2D(_MainTex, i.uv + float2(-1 * sin(i.vertex.y/100 + _Time[3])/50, sin(i.vertex.y/10 + _Time[3])/50));
                //col.rgb = col.rgb * 2 + 0.01;
                }
                
                

                /*
                if ((i.vertex.y * _ScreenParams.y) % 2 >= 1)
                col = tex2D(_MainTex, i.uv + float2(1 * (acos(sin((1 - i.vertex.y)/40 + _Time[3]))/ 20) * sin(_Time[2]), 0));
                else
                {
                col = tex2D(_MainTex, i.uv + float2(1 * (acos(cos(i.vertex.y/40 + _Time[3]))/ 20) * sin(_Time[2]), 0));
                }
                // + sin(_Time[3]) / 5
                */
                
                for (uint x = 0, ilen = _ColorListLength; x <= ilen; x++)
                {
                    if (all(0.01 >= abs(_ColorList[x].rgb - col.rgb)))
                    {
                        col.rgb = _ColorList[(x + _Cycle) % _ColorListLength].rgb;
                    }
				}
                
                //_Cycle = _Time[3] / _CycleTimer;
                

                //Notes: Used to detect Color. Need Tolerence for it to work!
                //if (all(0.03 >= abs(_MyColor.rgb - col.rgb)))
                //    col.rgb = col.rgb + sin(_Time[3] + i.vertex.y / 20)/3;        

				//abs(sin(_Time[3] + i.vertex.y / 20)) + 
                //col.rgb = _MyColor;
                
                // just invert the colors
                //col.rgb = 1 - col.rgb;
                //col.r = 1;

                return col;
            }
            ENDCG
        }
    }
}
