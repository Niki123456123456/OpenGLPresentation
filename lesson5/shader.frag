#version 140
precision highp float;

uniform vec2 size;
uniform float time;

void main()
{
    vec2 position = gl_FragCoord.xy / size;
    float color = abs(sin(time));
    gl_FragColor = vec4(position, color, 1.0);
}