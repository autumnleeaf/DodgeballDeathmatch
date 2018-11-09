#! /bin/sh

project="DodgeballDeathmatch"

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
 16   -batchmode \
 17   -nographics \
 18   -silent-crashes \
 19   -logFile $(pwd)/$project/unity.log \
 20   -projectPath $(pwd)/$project \
 21   -buildWindowsPlayer "$(pwd)/$project/Build/windows/$project.exe" \
 22   -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/$project/unity.log \
  -projectPath $(pwd)/$project \
  -buildOSXUniversalPlayer "$(pwd)/$project/Build/osx/$project.app" \
  -quit

echo 'Logs from build'
cat $(pwd)/$project/unity.log
