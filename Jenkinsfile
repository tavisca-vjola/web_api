pipeline {
    agent any
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')  
      string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
        
        
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
               
                bat 'dotnet $env:restoreCommand'
                bat 'dotnet $env:buildCommand'
            }
        }
        stage('Test') {
            
            steps {
                bat 'dotnet test $env:TEST_PATH'
            }
        }
        stage('Publish')
        {
            steps{
             bat 'dotnet publish $env:projectToBePublished -c Release -o artifacts'   
            }
            
        }
    }
    post
    {
        success{
         archiveArtifacts '**'
            
            bat "docker build -t %IMAGE_NAME% ." 
            bat "docker run -p 6000:80 %IMAGE_NAME%"
        }
        
        
    }
}
