#version 330
precision highp float;

uniform vec2 size;

struct circle
{
  vec2 center;
  float radius;
};


bool pointInCircle(vec2 point, circle c)
{
   // Todo Implemtiere die Methode
   // du kannst mit z.B. c.center auf die Eigenschaften des Kreises zugreifen
   return false;
}


void main()
{
    vec2 position = gl_FragCoord.xy / size;

    circle circle = circle(vec2(0.5), 0.5);


    if(pointInCircle(position, circle)){
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
        return;
    }
    gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
}   