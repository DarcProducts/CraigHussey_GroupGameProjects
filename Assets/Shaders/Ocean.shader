Shader "Custom/Ocean" {
    Properties {
        _MainTex ("Base Texture", 2D) = "white" {}
        _Tiling ("Tiling", float) = 1
        _Speed ("Speed", float) = 1
        _Wavelength ("Wavelength", float) = 0.1
        _WaveHeight ("WaveHeight", float) = 0.1
    }

    SubShader 
    {
        Tags {"Queue"="Geometry"}
        LOD 200
        Pass{
        CGPROGRAM
        #include "UnityCG.cginc"
        #pragma vertex vert
        #pragma fragment frag
        struct appdata 
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f 
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        sampler2D _MainTex;
        float _Speed;
        float _Wavelength;
        float _WaveHeight;
        float _Tiling;

        v2f vert (appdata v) 
        {
            v2f o;
            float x = v.uv.x * _Wavelength + _Speed * _Time.y;
            float y = v.uv.y * _Wavelength + _Speed * _Time.y;
            float y_pos = v.vertex.y + _WaveHeight * sin(x + y);
            o.vertex = UnityObjectToClipPos(float3(v.vertex.x, y_pos, v.vertex.z));
            o.uv = v.uv;
            return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
            fixed4 col = tex2D(_MainTex, i.uv * _Tiling);
            return col;
        }
        ENDCG
        }
    }
}


