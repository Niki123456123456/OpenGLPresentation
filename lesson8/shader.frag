#version 140
precision highp float;

uniform vec2 size;

void main()
{
    vec2 position = gl_FragCoord.xy / size;

    vec2 center = vec2(0.5);
    float radius = 0.25;

    float distance = distance(position, center);
    if(distance <= radius){
        // circle
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
        return;
    }
    // background
    gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
}