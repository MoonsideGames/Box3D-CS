#!/bin/sh
cat > tmp.c <<- EOM
#include "box3d/box3d.h"
EOM

./c2ffi tmp.c -I ../box3d/include -o GenerateBindings/assets/ffi.json
rm tmp.c
