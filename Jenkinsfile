pipeline {
     agent any
     
    parameters{
    
      string(name: 'USER_NAME', defaultValue: 'vjmsai', description: 'Enter User Name')
       string(name: 'REPO_NAME', defaultValue: 'webapi', description: 'Enter Repo Name')
       string(name: 'TAG_NAME', defaultValue: 'version', description: 'enter tag name')
         string(name:"PORT",defaultValue:"4544")
         
              

   
  
    }
    
    
   
       stages {
       
            stage('Docker Image Pulling')
            {
             steps
                 {
                  powershell(script:'docker pull  ${env:USER_NAME}/${env:REPO_NAME}:${env:TAG_NAME}') 
                 }
                 
            }
              stage('Docker Running')
              {
                steps
                     {
                                       
                          powershell(script:'docker run -p ${env:PORT}:80 ${env:USER_NAME}/${env:REPO_NAME}:${env:TAG_NAME}')  
                      }
                                  
              }
            
           
    }
    
}
