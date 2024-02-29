﻿/*
 * Copyright (C) 2010-2015 Nektra S.A., Buenos Aires, Argentina.
 * All rights reserved. Contact: http://www.nektra.com
 *
 *
 * This file is part of Deviare In-Proc
 *
 *
 * Commercial License Usage
 * ------------------------
 * Licensees holding valid commercial Deviare In-Proc licenses may use this
 * file in accordance with the commercial license agreement provided with the
 * Software or, alternatively, in accordance with the terms contained in
 * a written agreement between you and Nektra.  For licensing terms and
 * conditions see http://www.nektra.com/licensing/.  For further information
 * use the contact form at http://www.nektra.com/contact/.
 *
 *
 * GNU General Public License Usage
 * --------------------------------
 * Alternatively, this file may be used under the terms of the GNU
 * General Public License version 3.0 as published by the Free Software
 * Foundation and appearing in the file LICENSE.GPL included in the
 * packaging of this file.  Please review the following information to
 * ensure the GNU General Public License version 3.0 requirements will be
 * met: http://www.gnu.org/copyleft/gpl.html.
 *
 **/

#include "StdAfx.h"
#include "resource.h"
#include "dllmain.h"
#include "dlldatax.h"
#include "DeviareLiteCOM_i.c"

//-----------------------------------------------------------

CDeviareLiteCOMModule _AtlModule;
HINSTANCE hDllInst;

//-----------------------------------------------------------

static LONG __stdcall ICorJitCompiler_compileMethod(__in LPVOID lpThis, __in LPVOID comp, __in LPVOID info,
                                                    __in unsigned flags, __out BYTE **nativeEntry,
                                                    __out ULONG *nativeSizeOfCode);

//-----------------------------------------------------------

// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
  if (dwReason == DLL_PROCESS_ATTACH)
    hDllInst = hInstance;
#ifdef _MERGE_PROXYSTUB
  if (!PrxDllMain(hInstance, dwReason, lpReserved))
    return FALSE;
#endif
  return _AtlModule.DllMain(dwReason, lpReserved);
}

//-----------------------------------------------------------

CDeviareLiteCOMModule::CDeviareLiteCOMModule() : CAtlDllModuleT<CDeviareLiteCOMModule>()
{
  return;
}

CDeviareLiteCOMModule::~CDeviareLiteCOMModule()
{
  DotNetCoreHooks::Finalize();
  return;
}
