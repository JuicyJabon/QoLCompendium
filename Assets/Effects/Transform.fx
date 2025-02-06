sampler uImage : register(s0); // SpriteBatch.Draw content will be automatically bound to s0
sampler uTransformImage : register(s1); // Palette to get colors from
float uTime; // Scrolling effect

// Enchanting effects
float4 EnchantedFunction(float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage, coords);

	// any is false, i.e. transparent color, cannot be changed
    if (!any(color))
    {
        return color;
    }
    
    // Get the coordinates on the palette based on the uTextImage coordinates and uTime value. Pay attention to %1.0 to ensure that it is within the [0, 1) interval
    float2 barCoord = float2((coords.x * 0.2 - uTime * 0.5) % 1.0, (coords.y * 0.2 + uTime) % 1.0);
    if (barCoord.x < 0)
    {
        barCoord.x = 1 + barCoord.x;
    }
	
	// Choose a color on the palette
    return tex2D(uTransformImage, barCoord) * 0.6 + color;
}

technique Technique1
{
    pass EnchantedPass
    {
        PixelShader = compile ps_2_0 EnchantedFunction();
    }
}