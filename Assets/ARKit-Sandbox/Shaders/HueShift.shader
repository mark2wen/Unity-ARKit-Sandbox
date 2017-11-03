Shader "Custom/HueShift" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Shift("Hue Shift", float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _Shift;
		
		float3 hue(float3 color, float shift) {

			const float3  kRGBToYPrime = float3 (0.299, 0.587, 0.114);
			const float3  kRGBToI     = float3 (0.596, -0.275, -0.321);
			const float3  kRGBToQ     = float3 (0.212, -0.523, 0.311);

			const float3  kYIQToR   = float3 (1.0, 0.956, 0.621);
			const float3  kYIQToG   = float3 (1.0, -0.272, -0.647);
			const float3  kYIQToB   = float3 (1.0, -1.107, 1.704);

			// Convert to YIQ
			float   YPrime  = dot (color, kRGBToYPrime);
			float   I      = dot (color, kRGBToI);
			float   Q      = dot (color, kRGBToQ);

			// Calculate the hue and chroma
			float   hue     = atan2 (Q, I);
			float   chroma  = sqrt (I * I + Q * Q);

			// Make the user's adjustments
			hue += shift;

			// Convert back to YIQ
			Q = chroma * sin (hue);
			I = chroma * cos (hue);

			// Convert back to RGB
			float3    yIQ   = float3 (YPrime, I, Q);
			color.r = dot (yIQ, kYIQToR);
			color.g = dot (yIQ, kYIQToG);
			color.b = dot (yIQ, kYIQToB);

			return color;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			c.rgb = hue(c.rgb, _Shift);
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
