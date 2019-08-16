pipeline {
    agent any
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')    
        
    }
       stages {
        
        stage('Build') {
            steps {
               
                bat 'dotnet build %APPLICATION_PATH% -p:Configuration=release -v:n'
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
            
            bat 'docker build -t webmage .' 
            bat 'docker run -p 6000:80 webmage'
        }
        
        
    }
}
