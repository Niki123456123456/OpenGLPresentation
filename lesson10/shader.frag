#version 140
precision highp float;

uniform vec2 size;

struct circle
{
  vec2 center;
  float radius;
  float border;
};

float pointInCircle(vec2 point, circle c)
{
   float distance = distance(point, c.center);
   float s = 1.0 - smoothstep(c.radius * (1.0 - c.border), c.radius * (1.0 + c.border), distance);
   return s;
}

void main()
{
    vec2 position = gl_FragCoord.xy / size;
    // Todo zeichne eine weichere Kante & ändere die Farbe des Kreises
    circle circle = circle(vec2(0.5), 0.5, 0.001);

    gl_FragColor = vec4(vec3(pointInCircle(position, circle)), 1.0);
}       