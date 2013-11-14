This project tries to tackle a problem most .Net/Mono open source projects have:

- You want to sign your assemblies so they can be used by signed assemblies
- You do not want to give away those key files
- Your code should compile without hitches directly after cloning it

It is just an msbuild target that is executed before the actual CoreCompile. It will check whether the project has a key file and if that is the case whether that key file does exist.
If it doesn't, it will create one with that filename/path.

To use it, just install the [nuget package](https://www.nuget.org/packages/CreateSnkFile) into every project that is signed with a key file.