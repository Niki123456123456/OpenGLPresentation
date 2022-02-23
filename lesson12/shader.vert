attribute vec4 position;

uniform mat4 projectionMatrix;
uniform mat4 modelMatrix;

void main() 
{
    gl_Position = projectionMatrix * modelMatrix * position;
}   