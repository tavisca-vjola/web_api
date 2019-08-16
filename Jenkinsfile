pipeline {
    agent any
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')  
     string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
     string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
        
    }
    
   
       stages {
        
        stage('Build') {
            steps {
              
                powershell(script: 'dotnet build $APPLICATION_PATH -p:Configuration=release -v:n')
                
               
            }
        }
        stage('Test') {
            
            steps {
                powershell(script: 'dotnet test')
            }
        }
        stage('Publish')
        {
            steps{
            powershell(script: 'dotnet publish $APPLICATION_PATH -c Release -o artifacts')
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
