pipeline {
    agent any
    triggers {
        pollSCM '*/5 * * * *'
    }
    stages {
        stage('Hello') {
            steps {
                echo 'Hello World'
                
            }
        }
        stage('check out'){
            steps{
                echo 'Checkout repository'
            }
        }
    }
}