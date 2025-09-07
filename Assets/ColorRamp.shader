// Made with Amplify Shader Editor v1.9.5
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ColorRamp"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_Ramp("Ramp", 2D) = "white" {}
		_wenli("wenli", 2D) = "white" {}
		_wenli1("wenli", 2D) = "white" {}
		_Float0("Float 0", Range( 0 , 1)) = 0
		_Float1("Float 1", Range( 0 , 1)) = 0
		_Float3("Float 3", Range( 0 , 0.5)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Ramp;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform sampler2D _wenli1;
		uniform float4 _wenli1_ST;
		uniform float _Float3;
		uniform sampler2D _wenli;
		uniform float4 _wenli_ST;
		uniform float _Float0;
		uniform float _Float1;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float4 appendResult4 = (float4(tex2D( _MainTex, uv_MainTex ).r , i.uv_texcoord.y , 0.0 , 0.0));
			float4 tex2DNode2 = tex2D( _Ramp, appendResult4.xy );
			float2 uv_wenli1 = i.uv_texcoord * _wenli1_ST.xy + _wenli1_ST.zw;
			float4 lerpResult13 = lerp( tex2DNode2 , tex2D( _wenli1, uv_wenli1 ) , _Float3);
			float2 uv_wenli = i.uv_texcoord * _wenli_ST.xy + _wenli_ST.zw;
			float4 lerpResult9 = lerp( lerpResult13 , tex2D( _wenli, uv_wenli ) , tex2DNode2.b);
			o.Albedo = lerpResult9.rgb;
			float3 temp_cast_2 = (( _Float0 * tex2DNode2.r )).xxx;
			o.Specular = temp_cast_2;
			o.Smoothness = _Float1;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19500
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-144,64;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-160,224;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;None;6a1fc8c40ff592643af4e8a9a8a35532;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.DynamicAppendNode;4;128,80;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;2;336,-128;Inherit;True;Property;_Ramp;Ramp;1;0;Create;True;0;0;0;False;0;False;-1;None;3f3a58a4bdd281f45bdc9d4d267743e4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;14;800,32;Inherit;False;Property;_Float3;Float 3;7;0;Create;True;0;0;0;False;0;False;0;0;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;12;528,-16;Inherit;True;Property;_wenli1;wenli;3;0;Create;True;0;0;0;False;0;False;-1;None;14bb4baebd445ba4896d82520b3dd341;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;5;560,512;Inherit;False;Property;_Float0;Float 0;4;0;Create;True;0;0;0;False;0;False;0;0.959;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;8;224,304;Inherit;True;Property;_wenli;wenli;2;0;Create;True;0;0;0;False;0;False;-1;None;14bb4baebd445ba4896d82520b3dd341;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.LerpOp;13;957.5986,-111.1001;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.3433962;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;10;304,144;Inherit;False;Property;_Float2;Float 2;6;0;Create;True;0;0;0;False;0;False;0;0.093;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;912,384;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;528,384;Inherit;False;Property;_Float1;Float 1;5;0;Create;True;0;0;0;False;0;False;0;0.744;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;9;1040,80;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1232,64;Float;False;True;-1;2;ASEMaterialInspector;0;0;StandardSpecular;ColorRamp;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;;0;False;;False;0;False;;0;False;;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;1;1
WireConnection;4;1;3;2
WireConnection;2;1;4;0
WireConnection;13;0;2;0
WireConnection;13;1;12;0
WireConnection;13;2;14;0
WireConnection;11;0;5;0
WireConnection;11;1;2;1
WireConnection;9;0;13;0
WireConnection;9;1;8;0
WireConnection;9;2;2;3
WireConnection;0;0;9;0
WireConnection;0;3;11;0
WireConnection;0;4;6;0
ASEEND*/
//CHKSM=7CB565668E1C6B7752A207E8D966E06503B85795