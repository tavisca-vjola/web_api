pipeline {
    agent any
   
    stages {
        
        stage('Build') {
            steps {
               
                sh 'dotnet build webapi.sln -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            
            steps {
                sh 'dotnet test '
            }
        }
        stage('Publish')
        {
            steps{
             sh 'dotnet publish'   
            }
            
        }
    }
    post
    {
        always{
         archiveArtifacts '**'
            sh 'dotnet webapi/bin/Debug/netcoreapp2.2/webapi.dll'
            
        }
        
        
    }
}
