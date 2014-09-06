param($installPath, $toolsPath, $package, $project)
$files = (Join-Path $toolsPath 'drivers') | Get-ChildItem
foreach ($file in $files) {
	$project.ProjectItems.AddFromFile($file.FullName);
	$pi = $project.ProjectItems.Item($file.Name);
	$pi.Properties.Item("BuildAction").Value = [int]2;
	$pi.Properties.Item("CopyToOutputDirectory").Value = [int]2;
}