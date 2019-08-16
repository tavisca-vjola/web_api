pipeline {
    agent any
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')  
     string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
     string(name: 'GIT_REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
     string(name: 'APPLICATION_TEST_PATH', defaultValue: 'webapi/webapi.csproj')
      string(name: 'IMAGE_NAME', defaultValue: 'sia')
    }
    
   
       stages {
        
        stage('Build') {
            steps {
              
                powershell(script: 'dotnet build $APPLICATION_PATH -p:Configuration=release -v:n')
                
               
            }
        }
        stage('Test') {
            
            steps {
                powershell(script: 'dotnet test $APPLICATION_TEST_PATH')
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
             archiveArtifacts artifacts: 'webapi/bin/Debug/netcoreapp2.2/publish/*.*', fingerprint:true 
            }
        }
           stage('deploy') {
            steps {
                       
                        powershell(script:'docker build -t $IMAGE_NAME .')
                       powershell(script: 'docker run --rm -p 5000:789/tcp $IMAGE_NAME')

            }
        }
           
    }
    
}
