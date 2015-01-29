Shader "Custom/KeyboardBar" {
    Properties {
        _Color1 ("Color 1", Color) = (1, 0, 0, 0.5)
        _Color2 ("Color 2", Color) = (0, 0, 1, 0.5)
        _Alpha ("Alpha", float) = 1.0
    }
    Subshader {
        Tags { "RenderType" = "Transparent" }

        Pass {
            Cull Off
            ZWrite Off
            ZTest Off
            Fog { Mode off }
            Blend SrcAlpha OneMinusSrcAlpha
            
            GLSLPROGRAM

            uniform lowp vec4 _Color1;
            uniform lowp vec4 _Color2;
            uniform lowp float _Alpha;

            varying lowp vec4 color;

            #ifdef VERTEX
            void main() {
                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
                color = mix(_Color1, _Color2, gl_Position.x);
                color.w *= _Alpha;
            }
            #endif

            #ifdef FRAGMENT
            void main() {
                gl_FragColor = color;
            }
            #endif

            ENDGLSL
        }
    }
}
