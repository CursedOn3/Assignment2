# WeAreCars Rental System - Create Distribution Package
# This script creates a clean distribution folder ready for sharing

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "WeAreCars Rental System" -ForegroundColor Cyan
Write-Host "Distribution Package Creator" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Define paths
$publishFolder = "C:\Users\risha\OneDrive\Desktop\Assignment\WeAreCarsRentalSystemWinForms\bin\Release\net10.0-windows\win-x64\publish"
$desktopPath = [Environment]::GetFolderPath("Desktop")
$distFolder = Join-Path $desktopPath "WeAreCarsRentalSystem-Distribution"
$zipFile = Join-Path $desktopPath "WeAreCarsRentalSystem-v1.0.zip"

Write-Host "Creating distribution package..." -ForegroundColor Yellow
Write-Host ""

# Remove old distribution folder if exists
if (Test-Path $distFolder) {
    Write-Host "Removing old distribution folder..." -ForegroundColor Gray
    Remove-Item -Path $distFolder -Recurse -Force
}

# Remove old ZIP if exists
if (Test-Path $zipFile) {
    Write-Host "Removing old ZIP file..." -ForegroundColor Gray
    Remove-Item -Path $zipFile -Force
}

# Create new distribution folder
Write-Host "Creating distribution folder..." -ForegroundColor Green
New-Item -ItemType Directory -Path $distFolder | Out-Null

# Copy published files
Write-Host "Copying application files..." -ForegroundColor Green
Copy-Item -Path "$publishFolder\*" -Destination $distFolder -Recurse

# Show what was copied
Write-Host ""
Write-Host "Files included:" -ForegroundColor Cyan
Get-ChildItem -Path $distFolder | ForEach-Object {
    $size = if ($_.PSIsContainer) { "Folder" } else { "{0:N2} MB" -f ($_.Length / 1MB) }
    Write-Host "  ? $($_.Name) - $size" -ForegroundColor White
}

# Create ZIP file
Write-Host ""
Write-Host "Creating ZIP file..." -ForegroundColor Yellow
Compress-Archive -Path "$distFolder\*" -DestinationPath $zipFile

Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host "SUCCESS! Distribution package created" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""

Write-Host "Distribution folder: " -ForegroundColor Cyan -NoNewline
Write-Host "$distFolder" -ForegroundColor White
Write-Host ""
Write-Host "ZIP file: " -ForegroundColor Cyan -NoNewline
Write-Host "$zipFile" -ForegroundColor White
Write-Host ""

# Show ZIP file size
$zipSize = (Get-Item $zipFile).Length / 1MB
Write-Host "ZIP file size: " -ForegroundColor Cyan -NoNewline
Write-Host ("{0:N2} MB" -f $zipSize) -ForegroundColor White
Write-Host ""

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Next Steps:" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "1. Test the application:" -ForegroundColor White
Write-Host "   ? Open: $distFolder" -ForegroundColor Gray
Write-Host "   ? Run: WeAreCarsRentalSystemWinForms.exe" -ForegroundColor Gray
Write-Host ""
Write-Host "2. Share the ZIP file:" -ForegroundColor White
Write-Host "   ? File: $zipFile" -ForegroundColor Gray
Write-Host "   ? Share via email, USB, or cloud storage" -ForegroundColor Gray
Write-Host ""
Write-Host "3. Login credentials:" -ForegroundColor White
Write-Host "   ? Username: sta001" -ForegroundColor Gray
Write-Host "   ? Password: givemethekeys123" -ForegroundColor Gray
Write-Host ""

Write-Host "Press any key to open distribution folder..." -ForegroundColor Yellow
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

# Open the distribution folder
Start-Process explorer.exe $distFolder

Write-Host ""
Write-Host "Done! Distribution package ready for submission." -ForegroundColor Green
Write-Host ""
