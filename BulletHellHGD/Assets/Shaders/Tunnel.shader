Shader "Hidden/Tunnel"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TunnelSpeed ("Tunnel Speed", Range(0, 100.0)) = 0.0

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

			};
			
			sampler2D _MainTex;
			fixed _TunnelSpeed;

			fixed4 frag (v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
			{

				float2 x = -0.75 + 2.0 * screenPos.xy / _ScreenParams.xy;

				float s = atan2(x.y, x.x);
				float r = sqrt(dot(x,x));

				i.uv.x = _TunnelSpeed * _Time.y + 0.1/r;
				i.uv.y = s/3.1416;

				fixed4 col = tex2D(_MainTex, i.uv);


				return col;
			}
			ENDCG
		}
	}
}
