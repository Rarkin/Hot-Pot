// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Shader/Character"
{
	Properties
	{
		_Saucey_AO("Saucey_AO", 2D) = "white" {}
		_HairGreen_6("HairGreen_6", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _HairGreen_6;
		uniform float4 _HairGreen_6_ST;
		uniform sampler2D _Saucey_AO;
		uniform float4 _Saucey_AO_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_HairGreen_6 = i.uv_texcoord * _HairGreen_6_ST.xy + _HairGreen_6_ST.zw;
			o.Albedo = tex2D( _HairGreen_6, uv_HairGreen_6 ).rgb;
			float2 uv_Saucey_AO = i.uv_texcoord * _Saucey_AO_ST.xy + _Saucey_AO_ST.zw;
			o.Occlusion = tex2D( _Saucey_AO, uv_Saucey_AO ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14501
1927;29;1266;958;777;220;1;True;False
Node;AmplifyShaderEditor.SamplerNode;2;-404,339;Float;True;Property;_Saucey_AO;Saucey_AO;0;0;Create;True;0;8f3a518b21f12644aa88217b58a480e4;8f3a518b21f12644aa88217b58a480e4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;9;-376,19;Float;True;Property;_HairGreen_6;HairGreen_6;1;0;Create;True;0;f48315e079b9f4a4cba2fb0a0650e89b;f48315e079b9f4a4cba2fb0a0650e89b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Shader/Character;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;9;0
WireConnection;0;5;2;0
ASEEND*/
//CHKSM=8A5880CDCBD37CC8A1A659A26C11C2DDD87BC0BC