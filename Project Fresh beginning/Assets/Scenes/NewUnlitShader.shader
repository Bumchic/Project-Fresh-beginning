Shader "Custom/DarkOverlay"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _OverlayColor ("Overlay Color", Color) = (0, 0, 0, 0.5) // Default: semi-transparent black
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha // Ensures transparency works
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            fixed4 _OverlayColor;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 original = tex2D(_MainTex, i.texcoord); // Original sprite color
                fixed4 overlay = _OverlayColor; // Overlay color
                return lerp(original, overlay, overlay.a); // Blend based on overlay alpha
            }
            ENDCG
        }
    }
}
