#version 140
precision highp float;

uniform vec2 size;

void main()
{
    vec2 test = gl_FragCoord.xy / size;
    gl_FragColor = vec4(test, 1.0, 1.0);
}