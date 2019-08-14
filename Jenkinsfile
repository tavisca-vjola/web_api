pipeline {
    agent any
    parameters{
    string(name: 'REPO_PATH', defaultValue: 'https://github.com/tavisca-vjola/web_api.git')
        string(name: 'SOLUTION_PATH', defaultValue: 'webapi.sln')
        string(name: 'TEST_PATH', defaultValue: 'apitests/apitests.csproj')
    }
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
}
