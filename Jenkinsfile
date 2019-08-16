pipeline {
    agent any
    parameters{
    
        string(name: 'SOLUTION_PATH', defaultValue: 'webapi.sln')
        
    }
       stages {
        
        stage('Build') {
            steps {
               
                bat 'dotnet build %params.SOLUTION_PATH% -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            
            steps {
                bat 'dotnet test'
            }
        }
        stage('Publish')
        {
            steps{
             bat 'dotnet publish'   
            }
            
        }
    }
    post
    {
        success{
         archiveArtifacts '**'
            bat 'dotnet webapi/bin/Debug/netcoreapp2.2/webapi.dll'
            
        }
        
        
    }
}
