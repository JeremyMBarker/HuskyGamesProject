Shader "Hidden/SineWave"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_A_Value ("A Value", Float) = 0.001
		_B_Value ("B Value", FLoat) = 0.001
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma target 3.0
			
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			fixed _A_Value;
			fixed _B_Value;

			fixed4 frag(v2f_img i) : COLOR
			{
				i.uv.y = (sin(i.uv.x * 10.0) * sin(i.uv.y * .1)) + i.uv.y;
				fixed4 col = tex2D(_MainTex, i.uv);
		
				return col;
			}
			ENDCG
		}
	}
}
