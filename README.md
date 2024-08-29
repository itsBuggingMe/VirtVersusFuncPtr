## VirtVersusFuncPtr ##
A quick benchmark for comparing the speeds of function pointers and virtual method calls in C#.

| Method  | Mean     | Error     | StdDev    | Code Size |
|-------- |---------:|----------:|----------:|----------:|
| Virtual | 5.517 ns | 0.1274 ns | 0.1252 ns |      91 B |
| Pointer | 5.333 ns | 0.0723 ns | 0.0676 ns |      49 B |
| Normal  | 4.336 ns | 0.0955 ns | 0.0894 ns |      74 B |
