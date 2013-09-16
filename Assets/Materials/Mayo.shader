Shader "Custom/Mayo" {
	Properties {
        _Color ("Main Color (RGB)", Color) = (0.5, 0.5, 0.5, 1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert
        
        float4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb * 0.2f;
            o.Emission = _Color.rgb * 0.8f;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
