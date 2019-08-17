pipeline {
     agent any
     
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
     string(name:'IMAGE_NAME',defaultValue:'sai')  
     string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
     string(name: 'GIT_REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
     
      string(name: 'IMAGE_NAME', defaultValue: 'sia')
     choice(name: 'JOB', choices:  ['Test' , 'Build', 'Publish'])
    }
    
   
       stages {
        
        stage('Build') {
            
            
            steps {
              
                 powershell(script: 'dotnet build ${env:APPLICATION_PATH} -p:Configuration=release -v:n')
                
               
            }
        }
        stage('Test') {
             when
            {
                expression { params.JOB == 'Test'}
            }
            
            
            steps {
                 
                powershell(script: 'dotnet test')
            }
        }
        stage('Publish')
        {
             
          
            
            steps{
            bat 'dotnet publish' 
            
            }
            
        }
        //   stage('Archive')
        //{
          //  steps
           // {
            // powershell(script: 'compress-archive webapi/artifacts publish.zip -Update')
             //   archiveArtifacts artifacts: 'publish.zip' 
            //}
        //}
           stage('deploy') {
            steps {
                       
                       powershell(script: 'docker build -t ${env:IMAGE_NAME} ./')
                 
            }
        }
            
           
    }
    
}
