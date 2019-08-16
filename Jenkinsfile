pipeline {
    agent any
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')  
      string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
         string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
        
    }
    
    environment
    {
        projectToBePublished = 'webapi.sln'
        restoreCommand = 'dotnet restore $env:APPLICATION_PATH --source $env:NUGET_REPO'
        buildCommand = 'dotnet build $env:APPLICATION_PATH -p:Configuration=release -v:n'
    }
       stages {
        
        stage('Build') {
            steps {
               powershell(script: '$env:restoreCommand')
                powershell(script: '$env:buildCommand')
                
               
            }
        }
        stage('Test') {
            
            steps {
                powershell(script: 'dotnet test $env:TEST_PATH')
            }
        }
        stage('Publish')
        {
            steps{
            powershell(script: 'dotnet publish $env:projectToBePublished -c Release -o artifacts')
            }
            
        }
           stage('Archive')
        {
            steps
            {
                powershell(script: 'compress-archive webapi/artifacts publish.zip -Update')
                archiveArtifacts artifacts: 'publish.zip'    
            }
        }
    }
    post
    {
        success{
         
        }
        
        
    }
}
