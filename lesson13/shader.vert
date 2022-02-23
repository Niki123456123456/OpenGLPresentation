#version 140
precision highp float;

attribute vec4 position;
attribute vec4 color;

uniform mat4 projectionMatrix;
uniform mat4 modelMatrix;

varying lowp vec4 vColor;

void main() 
{
    gl_Position = projectionMatrix * modelMatrix * position;
    vColor = color;
}   