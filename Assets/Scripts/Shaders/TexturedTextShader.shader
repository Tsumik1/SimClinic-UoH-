// Upgrade NOTE: replaced 'PositionFog()' with multiply of UNITY_MATRIX_MVP by position
// Upgrade NOTE: replaced 'V2F_POS_FOG' with 'float4 pos : SV_POSITION'

Shader "LimitedColors/Binary" {
	Properties {
		_Color ("Pre-Calculative Color", Color) = (1,1,1,1) // this color gets applied before texture calculations take place
		_Col1 ("Color One", Color) = (.5,.5,.5,1) // one of the colors that the end fragment can become
		_Col2 ("Color Two", Color) = (0,0,0,1) // the second color that the end fragment can become
		_Ambient("Ambient Color", Color) = (1, 1, 1, 1) // the ambient light level.
		_Final("Final Color Multiplication", Color) = (1, 1, 1, 1) // this color is applied after all calculations (including colors are applied) have been completed
		_MainTex ("Base (RGB)", 2D) = "white" {} // main texture
		_Equa ("Equality Number ", float) = 2 // helps to determain what color range _Col1 & _Col2 should be applied to
		_Modulus ("Modulus Number", float) = 4 // helps to determain what color range _Col1 & _Col2 should be applied to
		_Multi ("Multiplication Number ", float) = 10 // determains how many "rings" should be made
		/* Note:
		*	The last 3 'floats' are converted to ints
		*/
	}
	#warning Upgrade NOTE: SubShader commented out; uses Unity 2.x per-pixel lighting. You should rewrite shader into a Surface Shader.
/*SubShader {
		
		Pass {
			Name "Lighting On"
			Tags { "LightMode" = "Pixel" } // do all of these calculations when a pixel light is using it
			CGPROGRAM
			// go through all the pragma and file includes
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_builtin
			#pragma fragmentoption ARB_fog_exp2
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			#include "AutoLight.cginc"
			
			// get our v2f struct ready
			struct v2f {
			    float4 pos : SV_POSITION;
			    LIGHTING_COORDS
			    float4 color : COLOR0;
			    float2  uv : TEXCOORD0;
			};
			
			// all of our uniform var's
			sampler2D _MainTex;
			float4 _Col1;
			float4 _Col2;
			float4 _Color;
			float4 _Ambient;
			float4 _Final;
			float _Equa;
			float _Modulus;
			float _Multi;
			
			// our actual texture calculation function
			float4 TextureCalculations (float4 tex, float4 lighting) {
				// get int version of floats
				int equa = _Equa;
				int mod = _Modulus;
				int multi = _Multi;
				// preform 'core' calculations
				tex *= _Color;
				tex[3] = 1;
				lighting[3] = 1;
				lighting += _Ambient;
				tex *= lighting; 
				float avrg = tex[0] + tex[1] + tex[2]; 
				avrg = avrg / 3;
				avrg *= multi;
				int tmp = avrg;
				tmp += tmp % 2;
				int asdf = avrg;
				if (asdf % mod == equa)
					tex = _Col1;
				else
					tex = _Col2;

				return tex * _Final;
			}
			
			
			
			v2f vert (appdata_base v) {
				// do basic lighting calculations, and UV calculations
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    float3 ldir = normalize( ObjSpaceLightDir( v.vertex ) );
			    float diffuse = dot( v.normal, ldir );
			    o.color = diffuse * _ModelLightColor0;
				o.uv = TRANSFORM_UV(0);
			    TRANSFER_VERTEX_TO_FRAGMENT(o);
			    return o;
			}

			float4 frag (v2f i) : COLOR { 
				float4 texcol = tex2D( _MainTex, i.uv ); // get a texture
				i.color = i.color * LIGHT_ATTENUATION(i) * 2; // get lighting
				texcol = TextureCalculations(texcol, i.color); // preform 'core' calculations
			    return texcol; // return results
			}
			ENDCG
		}
		
		
		
		Pass {
			Name "Lighting Off"
			// this one is quite similar to everything above, just more simple since it doesn't need to preform lighting calculations
			Tags { "LightMode" = "VertexOrNone" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_fog_exp2
			#include "UnityCG.cginc"
			
	
			struct v2f {
			    float4 pos : SV_POSITION;
			    float4 color : COLOR0;
			    float2  uv : TEXCOORD0;
			};
			sampler2D _MainTex;
			float4 _Col1;
			float4 _Col2;
			float4 _Color;
			float4 _Ambient;
			float4 _Final;
			float _Equa;
			float _Modulus;
			float _Multi;
			
			//Calculate texture
			float4 TextureCalculations (float4 tex, float4 lighting) {
				int equa = _Equa;
				int mod = _Modulus;
				int multi = _Multi;
				
				tex *= _Color;
				tex[3] = 1;
				lighting[3] = 1;
				lighting += _Ambient;
				tex *= lighting;
				float avrg = tex[0] + tex[1] + tex[2];
				avrg = avrg / 3;
				avrg *= multi;
				int tmp = avrg;
				tmp += tmp % 2;
				int asdf = avrg;
				if (asdf % mod == equa)
					tex = _Col1;
				else
					tex = _Col2;

				return tex * _Final;
			}
			
			
			
			v2f vert (appdata_base v) {
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_UV(0);
			    return o;
			}

			float4 frag (v2f i) : COLOR { 
				float4 texcol = tex2D( _MainTex, i.uv );
				i.color = 0;
				texcol = TextureCalculations(texcol, i.color);
			    return texcol;
			}
			ENDCG
		}
		
	}*/ 
	// get our fall back...
	FallBack "Diffuse", 1
}