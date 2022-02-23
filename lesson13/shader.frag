#version 140
precision highp float;

varying lowp vec4 vColor;

void main() 
{
    gl_FragColor = vColor;
}