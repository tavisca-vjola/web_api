pipeline {
    agent any
   
        
    stages {
        
        stage('Build') {
            steps {
                sh 'dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            
            steps {
                sh'dotnet test ${TEST_PATH}'
            }
        }
    }
