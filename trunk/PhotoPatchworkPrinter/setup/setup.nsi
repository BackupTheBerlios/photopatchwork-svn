!define PRODUCT_NAME "Photo Patchwork Printer"
!define PRODUCT_VERSION "NB_2006_06_20"
!define PRODUCT_PUBLISHER "Jonathan Riboux"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_INST_ROOT_KEY "HKLM"

!define BASE_DIR "..\"
!define OUT_DIR ".\"

!define ICONS_GROUP "${PRODUCT_NAME}"

!cd "${BASE_DIR}"

SetDatablockOptimize on
SetCompressor /FINAL bzip2

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "${OUT_DIR}\${PRODUCT_NAME}-${PRODUCT_VERSION}-setup.exe"
InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
ShowInstDetails hide
ShowUnInstDetails hide
XPStyle on
CRCCheck on

!include "MUI.nsh"
!include "sections.nsh"

# MUI Settings
#!define MUI_HEADERIMAGE
#!define MUI_HEADERIMAGE_BITMAP "setup\install-small.bmp"
#!define MUI_HEADERIMAGE_UNBITMAP "setup\uninstall-small.bmp"
#!define MUI_WELCOMEFINISHPAGE_BITMAP "setup\install-big.bmp"
#!define MUI_UNWELCOMEFINISHPAGE_BITMAP "setup\uninstall-big.bmp"
!define MUI_ABORTWARNING
#!define MUI_ICON "setup\install.ico"
#!define MUI_UNICON "setup\uninstall.ico"

# Welcome page
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE Application\license.txt
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

# Uninstaller pages
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

# Language files
#!insertmacro MUI_LANGUAGE "French"

# MUI end ------

Section "PhotoPatchworkPrinter" PhotoPatchworkPrinter
  SetOverwrite on

  SetOutPath "$INSTDIR\"
  File /r "Application\bin\Release\*.dll"
  File /r "Application\bin\Release\*.exe"

  CreateDirectory "$SMPROGRAMS\${ICONS_GROUP}"
  CreateShortCut "$SMPROGRAMS\${ICONS_GROUP}\${PRODUCT_NAME}.lnk" '"$INSTDIR\PhotoPatchworkPrinter.exe"' '' "$INSTDIR\PhotoPatchworkPrinter.exe"
  CreateShortCut "$SMPROGRAMS\${ICONS_GROUP}\Uninstall.lnk" "$INSTDIR\uninst.exe" "" "$INSTDIR\uninst.exe"
SectionEnd

Section "-Post"
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  #WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "${PRODUCT_STARTMENU_REGVAL}" "${ICONS_GROUP}"
  #WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
  WriteRegStr ${PRODUCT_INST_ROOT_KEY} "Software\${PRODUCT_PUBLISHER}\${PRODUCT_NAME}" "WorkspaceDir" "${WORKSPACE_DIR}"
SectionEnd

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${ECLIPSE} "${PRODUCT_NAME}"
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Function un.onInit

FunctionEnd

Section Uninstall
  #ReadRegStr ${ICONS_GROUP} ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "${PRODUCT_STARTMENU_REGVAL}"

  RMDir /r "$SMPROGRAMS\${ICONS_GROUP}"
  RMDir /r "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  SetAutoClose true
SectionEnd
