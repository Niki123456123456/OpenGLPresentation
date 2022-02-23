#version 140
precision highp float;

void main()
{
    // Todo ändere den divisor, sodass ein schöner Verlauf entsteht 
    vec2 test = gl_FragCoord.xy / 200.0;
    gl_FragColor = vec4(test, 1.0, 1.0);
}