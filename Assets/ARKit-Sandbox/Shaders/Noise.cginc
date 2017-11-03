float hash( float n )
{
    return frac(sin(n)*43758.5453123);
}

float noise(float x) 
{
	float i = floor(x);  // integer
	float f = frac(x);  // fraction
	float u = f * f * (3.0 - 2.0 * f ); // custom cubic curve
	return lerp(hash(i), hash(i + 1.0), u); // using it in the interpolation
}