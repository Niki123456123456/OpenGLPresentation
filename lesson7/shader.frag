#version 330
precision highp float;

uniform vec2 size;

bool pointInRectrangle(vec2 point, vec2 center, vec2 size)
{
    // Todo implement
    return false;
}


void main()
{
    vec2 position = gl_FragCoord.xy / size;

    vec2 rectangleCenter = vec2(0.25);
    vec2 rectangleSize = vec2(0.1);

    if(pointInRectrangle(position, rectangleCenter, rectangleSize)){
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
        return;
    }
    gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
}