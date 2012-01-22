$framework = '4.0'

properties {
  $msbuild = "c:/Windows/Microsoft.NET/Framework/v4.0.30319/msbuild.exe"
  $rootDir = Resolve-Path .
  $buildDir = Join-Path $rootDir 'build'
  $srcDir = Join-Path $rootDir 'src'
  $binDir = Join-Path $rootDir 'bin'
  $packagesDir = Join-Path $rootDir 'src\packages'
  $nunitDir = Join-Path $packagesDir 'NUnit.2.5.10.11092\tools'
  $nunit = Join-Path $nunitDir "nunit-console.exe"
  $nunitTestsNUnitFile = Join-Path $rootDir "NUnitTests.nunit"
  $solutionFile = Join-Path $srcDir 'jiggler.sln'
}

task ? -description "Helper to display task info" {
    Write-Documentation
}

task default -depends UnitTests

task Compile -description "Simple compile" { 
  RunMsBuild "Build"
}

task RunAllTests -depends Compile -description "Runs all tests"{
  RunAllTests
}

task CompileAndPackage -depends Compile, Package -description "Build and package." {
}

task CompilePackageAndTest -depends Compile, Package -description "Build, package, and test." {
  RunUnitTests
}

function RunMsBuild($target) {
  exec { 
    & $msbuild "$solutionFile" /target:"$target" /verbosity:minimal /nologo
  }
}

task UnitTests -depends Compile -description "Unit Tests" {
  RunUnitTests
}

function RunUnitTests {
  exec{ & $nunit $nunitTestsNUnitFile /nologo "/exclude=EndToEnd,Integration" }
}

function RunAllTests {
  exec{ & $nunit $nunitTestsNUnitFile /nologo }
}

task EndToEndTests -depends Package {
  exec{ & $nunit $nunitTestsNUnitFile /nologo "/include=EndToEnd" }
}

task IntegrationTests -depends Compile {
  exec{ & $nunit $nunitTestsNUnitFile /nologo "/include=Integration" }
}
