Shader "Hidden/GrayScale.shader"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_LuminosityAmount("GrayScale Amount", Range(0.0, 1.0)) = 1.0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Pass{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			uniform sampler2D _MainTex;
			fixed _LuminosityAmount;

			fixed4 frag(v2f_img i) : COLOR
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				float luminosity = 0.5 * renderTex.r + 0.5 * renderTex.g + 0.5 * renderTex.b;
				fixed4 finalColor = lerp(renderTex, luminosity, _LuminosityAmount);

				return finalColor;
			}
			ENDCG
		}

	}
}
