# /bin/bash

./build.sh
mkdir -p ../LoadAssembly/bin/Debug/net5.0/Assembly
rm ../LoadAssembly/bin/Debug/net5.0/Assembly/*.dll

cp ../Assembly2/bin/Debug/net5.0/Assembly2.dll ../LoadAssembly/bin/Debug/net5.0/Assembly/

cd ../LoadAssembly/bin/Debug/net5.0/
./LoadAssembly

cd -

