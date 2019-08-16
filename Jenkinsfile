pipeline {
    agent any

       stages {
        
        stage('Build') {
            steps {
               
                bat 'dotnet build webapi.sln -p:Configuration=release -v:n'
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
            
            bat 'docker build -t webapiimage .' 
            bat 'docker run -p 6000:80 webapiimage'
        }
        
        
    }
}
