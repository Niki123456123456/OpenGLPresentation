#version 140
precision highp float;

uniform vec2 size;

void main()
{
    vec2 position = gl_FragCoord.xy / size;

    // Todo horizontaler anstatt vertikaler Balken
    if(position.x > 0.5){
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
        return;
    }
    gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
}