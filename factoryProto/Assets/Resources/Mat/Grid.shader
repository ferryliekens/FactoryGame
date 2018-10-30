// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Grid" {

	Properties{
		_GridThickness("Grid Thickness", Float) = 0.01
		_GridSpacing("Grid Spacing", Float) = 10.0
		_GridColour("Grid Colour", Color) = (0.5, 1.0, 1.0, 1.0)
		_BaseColour("Base Colour", Color) = (0.0, 0.0, 0.0, 0.0)
	}

		SubShader{
		Tags{ "Queue" = "Transparent" }

		Pass{
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM


#pragma vertex vert
#pragma fragment frag


	uniform float _GridThickness;
	uniform float _GridSpacing;
	uniform float4 _GridColour;
	uniform float4 _BaseColour;


	struct vertexInput {
		float4 vertex : POSITION;
	};


	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 worldPos : TEXCOORD0;
	};


	vertexOutput vert(vertexInput input) {
		vertexOutput output;
		output.pos = UnityObjectToClipPos(input.vertex);
		
		output.worldPos = mul(unity_ObjectToWorld, input.vertex);
		return output;
	}


	float4 frag(vertexOutput input) : COLOR{
		if (frac(input.worldPos.x / _GridSpacing) < _GridThickness || frac(input.worldPos.y / _GridSpacing) < _GridThickness) {
			return _GridColour;
		}
		else {
			return _BaseColour;
		}
	}
		ENDCG
	}
	}
}