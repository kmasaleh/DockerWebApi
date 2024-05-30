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
	agent any


	 parameters {
		string(name:PRJ_TARGETED_FRAMEWORK,defaultValue:'8',description:'.Net Framework')
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
		
		stage('Restore') {
			when {expression {env.BRANCH_NAME.startsWith("nana")}}
			steps {
					restoreSolutionDependencies()
			}
		}

		stage('Restore Dependencies') {
            steps {
                // Navigate to the project directory
                dir('dotnet-project') {
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