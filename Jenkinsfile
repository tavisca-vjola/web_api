pipeline {
     agent any
     
    parameters{
     string(name:'APPLICATION_PATH',defaultValue:'webapi.sln')
 
     string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
     string(name: 'GIT_REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
     string(name:'DOCKER_HUB_USERNAME',defaultValue:'vjmsai')
     string(name: 'DOCKER_HUB_CREDENTIALS_ID', defaultValue: 'docker-hub-credentials')
     string(name: 'DOCKER_IMAGE_NAME', defaultValue: 'demo-api', description: 'Name of the image to be created')
      string(name: 'DOCKER_IMAGE_TAG', defaultValue: 'version', description: 'Release information')
   
     choice(name: 'JOB', choices:  ['Test' , 'Build', 'Publish'])
    }
    
     enviroment
     {
          artifactsDirectory = "MyArtifacts"   
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
                 powershell(script: 'dotnet publish') 
             
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
         stage('Docker Creation')
        {
            steps
            {
                powershell "mv Dockerfile ${env.APPLICATION_PATH}/${env.artifactsDirectory}"
            }
        }
        stage(' Docker Image')
        {
            steps 
            {
                script 
                {
                    dir("${env.APPLICATION_PATH}/${env.artifactsDirectory}") 
                    {
                        
                        powershell "docker build -t ${env.DOCKER_HUB_USERNAME}/${env.DOCKER_IMAGE_NAME}:${env.DOCKER_IMAGE_TAG} --build-arg LaunchFile='${env.APPLICATION_PATH}.dll' ."
                    }
                }
            }
        }
            
           
    }
    
}
