def enableContentSecurityPolicyForReport(){
    script {System.setProperty("hudson.model.DirectoryBrowserSupport.CSP", "default-src 'self'; style-src 'self' 'unsafe-inline';");}
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
def  getGitChanges(){
	echo 'checking if code changed ...'
	def changes = false
    changes = currentBuild.changeSets.any { it.items.length > 0 }
	if (changes) {
          echo "Changes detected."
         // Add your actions here for when changes are detected
    } 
	else {
         echo "No changes detected."
	      // Add your actions here for when no changes are detected
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
def restoreSolutionDependencies() {
  echo "solution : ${params.PRJ_SLN_NAME}"
  echo "framework : ${PRJ_TARGETED_FRAMEWORK}"
  dotnetRestore project: "DockWebApi.sln", sdk: "dotnet${PRJ_TARGETED_FRAMEWORK}", verbosity: 'n'
 // sh """#!/bin/bash
 // ${DOTNET_CLI_HOME}//dotnet restore ${params.PRJ_SLN_NAME}.sln
 // """
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
CODE_CHNAGES = getGitChanges()
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
pipeline{
	docker {
            image 'jenkins/agent:alpine-jdk11' // Replace with the Docker image name
            label 'jenkins/agent-2' // Optional label to specify a specific Docker-capable agent
            args '-u root' // Specify the user as root
        }


	 parameters {
		string(name:'PRJ_TARGETED_FRAMEWORK',defaultValue:'8',description:'.Net Framework')
        string(name: 'BRANCH_NAME', defaultValue: 'nana', description: 'Branch to build')
        booleanParam(name: 'DEPLOY_TO_PROD', defaultValue: true, description: 'Deploy to production')
    }

	stages{
		stage('Init') {
			when {expression {env.BRANCH_NAME.startsWith("nana")}}
			steps {
				//enableContentSecurityPolicyForReport()
				deleteDir()
				// cleanWs()
				script{
					def buildNumber = env.BUILD_NUMBER
                    echo "The current build number is: ${buildNumber}"
					def brnachName = env.BRANCH_NAME
					echo "branch name is ${brnachName}"
					
				}
			}
		}
		stage('Checkout Branch') {
            steps {
                // Check out a specific branch using the 'checkout' step
                checkout([$class: 'GitSCM', branches: [[name: env.BRANCH_NAME]], userRemoteConfigs: [[url: 'https://github.com/kmasaleh/DockerWebApi.git']]])
            }
        }
        
		stage('install sdk') {
			steps{
			  sh '''
				sudo apt-get update && \
				sudo apt-get install -y wget apt-transport-https && \
				sudo wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
				dpkg -i packages-microsoft-prod.deb && \
				sudo  apt-get update && \
				sudo  apt-get install -y dotnet-sdk-8.0
	     		'''
			
			}
		}
		
		stage('Restore') {
			when {expression {env.BRANCH_NAME.startsWith("nana")}}
			steps {
					//restoreSolutionDependencies()
					echo 'restore'
					script {
						def fileList = sh(script: 'ls', returnStdout: true).trim()
					    echo "Available files in current directory: ${fileList}"
				    }

					sh '''
					 dotnet restore
					'''

			}

		}

		stage('Restore Dependencies') {
            steps {
                // Navigate to the project directory
                dir('DockerWebApi') {
                    // Restore dependencies using dotnet restore
                    //sh 'dotnet restore'

                }
            }
        }


		stage('build'){
			when{
				expression{
					env.BRANCH_NAME == 'nana' //&& env.CODE_CHNAGES==true
				}
			}
			steps{
				echo 'building application nana branch...'
				sh '''
					 dotnet build
					'''

			}
		}
		stage('test'){
			steps{
				echo 'testing application ...'
			}
		}

		stage('deploy'){
			steps{
				echo 'deploying application ...'
			}
		}

	}

}