pipeline {
     agent any
     
    parameters{
    
      string(name: 'USER_NAME', defaultValue: 'vjmsai', description: 'Enter Login')
       string(name: 'REPO_NAME', defaultValue: '', description: 'Enter Password')
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
              stage
              {
                steps('Docker Running')
                     {
                                       
                          powershell(script:'docker run -p ${env:PORT_NAME}:80 ${env:REPO_NAME}:${env:TAG_NAME}')  
                      }
                                  
              }
            
           
    }
    
}
